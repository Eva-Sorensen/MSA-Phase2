import axios from "axios";
import React, { useState } from "react";
import "./App.css";

function App() {
  const [countryName, setCountryName] = useState("");
  const [countryData, setCountryData] = useState<undefined | any>(undefined);

  const COUNTRY_API_URL_START = "https://restcountries.com/v3.1/name/";

  return (
    <div className="App">
      <div>
        <h1>COUNTRY FACTS</h1>

        <div>
          <label>Enter a country:</label>
          <br />
          <input
            type="text"
            id="country-name"
            name="country-name"
            onChange={(e) => setCountryName(e.target.value)}
          />
          <br />
          <button onClick={search}>Search</button>
        </div>

        <p>You have entered {countryName}</p>
      </div>
    </div>
  );

  async function search() {
    try {
      const res = await axios.get(COUNTRY_API_URL_START + countryName);
      if (res.status === 200) {
        console.log(res.data);
      } else {
        console.log(res.status);
      }
    } catch {
      console.log("Something went wrong");
    }
  }
}

export default App;
