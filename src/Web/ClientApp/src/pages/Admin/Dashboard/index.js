import { useDispatch, useSelector } from "react-redux";
import Layout from "../../../components/Admin/Layout/layout";
import { Doughnut, Bar, Line } from "react-chartjs-2";
import {
  Chart,
  ArcElement,
  BarElement,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Tooltip,
  Legend,
} from "chart.js";
import { setIsLoading } from "../../../services/stateService/redux/redux";
import { useState } from "react";
import AdminStyle from "../../../styles/Admin/style.module.css";

Chart.register(
  ArcElement,
  BarElement,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Tooltip,
  Legend
);

export default function Dashboard() {
  const dispatch = useDispatch();
  const [loading, setLoading] = useState(false);

  const handleToggle = () => {
    setLoading(!loading);
    dispatch(setIsLoading(!loading)); // Fix the toggle logic here
  };

  const labels = ["A", "B", "C"];
  const data = {
    labels: labels,
    datasets: [
      {
        label: "Dataset 1",
        data: [65, 59, 80],
        fill: true,
        backgroundColor: "rgb(75, 192, 192)",
        borderColor: "rgba(75, 192, 192, 0.2)",
      },
    ],
  };

  return (
    <>
      <div className="flex gap-6 p-5">
        <div className={AdminStyle.box}>
          <div className="content font-bold flex justify-between">
            Total Task <span className="Counter text-7xl">0</span>
          </div>
        </div>
        <div className={AdminStyle.box}>
          <div className="content">
            Completed Task <span className="Counter text-7xl">0</span>
          </div>
        </div>
        <div className={AdminStyle.box}>
          <div className="content">
            Remaining Task <span className="Counter text-7xl">0</span>
          </div>
        </div>
      </div>

      <div className="GraphCover text-white flex">
        <div className="task_Activity w-3/6">
          <Line
            data={data}
            options={{
              responsive: true,
              plugins: {
                legend: {
                  display: true,
                  position: "top",
                },
                tooltip: {
                  mode: "index",
                  intersect: false,
                },
              },
            }}
          />
        </div>

        <div className="doughnut flex">
          
        </div>
      </div>
    </>
  );
}
