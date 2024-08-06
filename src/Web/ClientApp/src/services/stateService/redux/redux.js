import { configureStore, createSlice } from "@reduxjs/toolkit";
import {
  persistStore,
  persistReducer,
  FLUSH,
  REHYDRATE,
  PAUSE,
  PERSIST,
  PURGE,
  REGISTER,
} from "redux-persist";
import { combineReducers } from "@reduxjs/toolkit";
import storage from "redux-persist/lib/storage";
import Cookies from "js-cookie";
//#region Application Initial States
const initialApplicationState = {
  isLoading: false,
  isSubmitting: false,
};

const initialUserState = {
  Name: "",
  Username: "",
  isAuth: false,
  Email: "",
  Roles: [],
  Token: "",
};

//#endregion

//#region  Application Slices
const userSlice = createSlice({
  name: "UserState",
  initialState: initialUserState,
  reducers: {
    setUserState: (state, action) => {
      return { ...state, ...action.payload };
      // state.Token = action.payload.Token;
      // state.Name = action.payload.Username;
    },
    resetState: () => initialUserState,
  },
});

const appSlice = createSlice({
  name: "Application State",
  initialState: initialApplicationState,
  reducers: {
    setIsLoading: (state, action) => {
      state.isLoading = action.payload;
    },
  },
  extraReducers:(builder)=>{
    builder.addCase(REHYDRATE,(state,action)=>{
      return { ...state, ...initialApplicationState }
    })
  }
});
//#endregion

const persistConfig = {
  key: "root",
  storage,
};
const combinedReducers = combineReducers({
  user: userSlice.reducer,
  application: appSlice.reducer,
});
const persistedReducer = persistReducer(persistConfig, combinedReducers);

const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
      },
    }),
});

export const { setUserState, resetState } = userSlice.actions;
export const { setIsLoading } = appSlice.actions;
export const persistor = persistStore(store);
export const resetAllState = () => (state, action) => {
  Cookies.remove("auth_token");
  state = undefined;
};

export default store;
