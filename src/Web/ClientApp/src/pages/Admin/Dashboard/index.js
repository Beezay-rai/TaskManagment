import { useDispatch } from "react-redux";
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
import { useEffect, useState } from "react";
import AdminStyle from "../../../styles/Admin/style.module.css";
import CountUp from "react-countup";
import { useRouter } from "next/router";
import { HubConnectionBuilder } from "@microsoft/signalr";
import MyHeader from "../../../components/Utilities/header";

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
  const [connection, setConnection] = useState(null);
  const [messages, setMessages] = useState([]);
  const [inputMessage, setInputMessage] = useState("");

  useEffect(() => {
    // Set up SignalR connection when the component mounts
    const newConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:7131/chathub")
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);

    newConnection
      .start()
      .then(() => console.log("Connected to SignalR hub"))
      .catch((err) => console.error("Error connecting to hub:", err));

    newConnection.on("ReceiveMessage", (message) => {
      setMessages((prevMessages) => [...prevMessages, message]);
    });

    return () => {
      // Clean up the connection when the component unmounts
      newConnection
        .stop()
        .then(() => console.log("Disconnected from SignalR hub"));
    };
  }, []);

  const handleChat = async () => {
    if (connection && inputMessage) {
      try {
        await connection.invoke("SendMessage", inputMessage);
        setInputMessage(""); // Clear the input field after sending
      } catch (err) {
        console.error("Error sending message:", err);
      }
    }
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
            Total Task
            <CountUp
              className="Counter text-7xl"
              duration={5}
              start={0}
              end={150}
            />
          </div>
        </div>
        <div className={AdminStyle.box}>
          <div className="content font-bold flex justify-between">
            Total Task
            <CountUp
              className="Counter text-7xl"
              duration={5}
              start={0}
              end={50}
            />
          </div>
        </div>
        <div className={AdminStyle.box}>
          <div className="content font-bold flex justify-between">
            Total Task
            <CountUp
              className="Counter text-7xl"
              duration={5}
              start={0}
              end={40}
            />
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

        <div className="chatbot">
          <input
            className="text-black"
            value={inputMessage}
            onChange={(e) => setInputMessage(e.target.value)}
            placeholder="Type your message..."
          />
          <input
            type="button"
            onClick={handleChat}
            className="btn btn-primary"
            value="Send"
          />
          <ul id="discussion">
            {messages.map((message, index) => (
              <li key={index}>{message}</li>
            ))}
          </ul>
        </div>
      </div>
    </>
  );
}
