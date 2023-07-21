import { useEffect, useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";

type HostingStuff = {
  hostName: string;
};

function App() {
  const [count, setCount] = useState(0);

  console.log(`Vite Env: ${import.meta.env.VITE_ENV_NAME as string}`);

  useEffect(() => {
    async function getData() {
      const res = await fetch(
        `${
          import.meta.env.VITE_API_BASE_URL as string
        }/api/WeatherForecast/GetEnv`
      );
      const data = (await res.json()) as HostingStuff;
      console.log(`DotNet Env: ${data.hostName}`);
    }

    getData();
  });

  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  );
}

export default App;
