import { NextResponse } from "next/server";
import { NextRequest } from "next/server";
import { useRouter } from "next/router";



const unauthPath=[
  "/",
  "/Auth/Login",
];

export default function middleware(request) {
  let authToken = request.cookies.get("auth_token");

  if(unauthPath.includes(request.nextUrl.pathname)){
    return NextResponse.next();

  }

  if (authToken === null || authToken === undefined) {
    return NextResponse.redirect(new URL("/Auth/Login", request.url));
  }
}
export const config = {
  matcher: ["/((?!.+\\.[\\w]+$|_next).*)", "/", "/(api|trpc)(.*)"],
};
