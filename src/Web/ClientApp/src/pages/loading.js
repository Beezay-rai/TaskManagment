import { ScaleLoader } from "react-spinners";

export default function Loader() {
  return (
    <ScaleLoader
      loading={true}
      color="rgb(0, 76, 255)"
      height={150}
      width={30}
      className="loader"
    />
  );
}
