import Image from "next/image";
import logo from "../assests/logo.jpg";
import backgroundImg from "../assests/landingpageBg.jpg";
import Link from "next/link";
import LocationOnIcon from "@mui/icons-material/LocationOn";
import EmailIcon from "@mui/icons-material/Email";
import LocalPhoneIcon from "@mui/icons-material/LocalPhone";
import MenuIcon from "@mui/icons-material/Menu";
import { useState } from "react";
import FacebookIcon from '@mui/icons-material/Facebook';
import XIcon from '@mui/icons-material/X';
import GoogleIcon from '@mui/icons-material/Google';

export default function index() {
  const [navItem, setNavItem] = useState(false);
  const handleNavItem = () => setNavItem(!navItem);

  return (
    <>
      <nav className="w-full">
        <div className="flex justify-between ">
          <div className="logo">
            <Image src={logo} width={100} height={100} />
          </div>
          <div className="nav-items flex  align-middle">
            <button className="btn lg:hidden" onClick={handleNavItem}>
              <MenuIcon className="text-black" />{" "}
            </button>

            <div className="hidden lg:flex">
              <ul
                className={`${
                  navItem ? `flex` : `hidden`
                }  items-center gap-9 lg:flex  md:flex-row `}
              >
                <li className="hover:to-blue-400">
                  <a className="font-bold text-lg " href="">
                    Home
                  </a>
                </li>
                <li className="font-bold text-lg ">About Us</li>
                <li className="font-bold text-lg ">Blog</li>
                <li className="font-bold text-lg ">Contact</li>
              </ul>
            </div>
          </div>
          <div className="hidden login-section lg:flex items-center">
            <a href="Auth/Login">
              <button className="bg-blue-900 flex text-white p-6 rounded-3xl h-7 content-center items-center mr-4">
                Get Started
              </button>
            </a>
          </div>
        </div>
      </nav>

      <div className="body w-full h-screen">
        <div
          className="body1 w-full  relative  "
          style={{
            height: "646px",
          }}
        >
          <Image
            src={backgroundImg}
            alt="Landing Page Background"
            layout="fill"
            objectFit="cover"
            className="w-full relative "
          />

          <div className="Card text-white  w-full  bg-black opacity-80  h-full  p-6 flex  items-center justify-center">
            <div className="flex flex-col items-center">
              <text
                className="font-extrabold outline outline-black outline-2"
                style={{
                  fontFamily: "League Gothic",
                  fontSize: "100px",
                }}
              >
                Manage Your Task Efficiently
              </text>
              <text>"Stay Organized, Achieve More."</text>
            </div>
          </div>
        </div>
      </div>

      <div className="bg-neutral-900 h-fit px-10 pt-10">
        <div className="flex text-white flex-wrap  justify-around">
          <div className="location w-fit">
            <ul>
              <li className="flex gap-3 mb-3">
                <LocationOnIcon fontSize="large" />
                <p>
                  21 Revolution Street, <br />
                  <h1 className="font-bold  text-lg"> Paris , France</h1>
                </p>
              </li>
              <li   className="flex gap-3 mb-3">
                <LocalPhoneIcon fontSize="large"/>
                <text className="font-bold  text-lg">+12 1235-4564</text>
              </li>
              <li  className="flex gap-3" >
                <EmailIcon fontSize="large" />
                <a href="#" className="font-bold  text-lg text-blue-600">
                  support@gmail.com
                </a>
              </li>
            </ul>
          </div>


          <div className="w-[50%]">
            <h5 className="font-bold text-2xl mb-2">
              About Task Management System
            </h5>
            <p className="text-slate-600 text-sm">
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras
              gravida metus vestibulum sapien facilisis consequat vitae ultrices
              lorem. Duis finibus, tortor eget dignissim euismod, nisi nisl
              tristique ligula, vitae tincidunt enim neque sed risus. Nulla
              posuere aliquam arcu non iaculis. Nam nisl tortor, accumsan vitae
              lacinia et, sollicitudin eu erat. Morbi non aliquam libero, sed
              faucibus mi. Ut ut turpis lorem. Duis nec faucibus mauris. Proin
              et orci vel ante tempor consequat sed eget mauris. Phasellus nec
              libero lacus. Etiam ex diam, sollicitudin quis tempus ut,
              hendrerit vel metus. Vivamus dictum risus vitae sem hendrerit, vel
              commodo leo hendrerit.
            </p>
          </div>
        
      
        </div>

        <div className="flex justify-center mt-20 border-t-2 border-gray-600 p-5 pt-20">
          <div className="text-white flex flex-col gap-5">
            <div className="flex gap-5">
              <FacebookIcon fontSize="large" />
              <XIcon fontSize="large" />
              <GoogleIcon fontSize="large" />
            </div>

            <p className="text-sm text-gray-600"> &copy; All rights reserved.</p>
          </div>
        </div>
      </div>
    </>
  );
}
