import { configureStore, createSlice } from "@reduxjs/toolkit";
import { persistStore, persistReducer } from "redux-persist";
import { combineReducers } from "@reduxjs/toolkit";
import storage from "redux-persist/lib/storage";

//#region Application Initial States
const initialApplicationState = {
  isLoading: "false",
  isSubmitting: false,
};

const initialUserState = {
  Name: "",
  Username: "",
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
      state.Token = action.payload.Token;
      state.Name = action.payload.Username;
    },
    resetState: () => (state = initialUserState),
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
});

export const { setUserState, resetState } = userSlice.actions;
export const persistor = persistStore(store);
export default store;
