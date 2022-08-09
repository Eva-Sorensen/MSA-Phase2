import axios from "axios";
import React, { useState } from "react";
import "./App.css";
import { CountryData } from "./types";
import { MapContainer, Marker, Popup, TileLayer, useMap } from "react-leaflet";
import { render } from "react-dom";

function App() {
  const [countryName, setCountryName] = useState("");
  const [countryData, setCountryData] = useState<undefined | CountryData>(
    undefined
  );

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

        {countryData === undefined ? (
          <p>Country not found</p>
        ) : (
          <div className="country-data">
            <div className="country-data-header">
              <img src={countryData.flags.png} alt={countryName + "'s flag"} />
              <h2>
                {countryData.name.official} ({countryData.name.common})
              </h2>
            </div>
            <div id="map">
              <MapContainer
                className="map"
                center={countryData.latlng}
                zoom={4}
                scrollWheelZoom={false}
              >
                <TileLayer
                  attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                  url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />
                <Marker position={countryData.latlng}>
                  <Popup>
                    A pretty CSS3 popup. <br /> Easily customizable.
                  </Popup>
                </Marker>
              </MapContainer>
            </div>

            <div className="country-data-info">
              <p>
                {countryData.continents.length === 1
                  ? "Continent:"
                  : "Continents:"}
                {countryData.continents.map((continent, index) => (
                  <span className="info" key={index}>
                    {continent}
                  </span>
                ))}
              </p>
              <p>
                {countryData.capital.length === 1 ? "Capital:" : "Capitals:"}
                {countryData.capital.map((capital, index) => (
                  <span className="info" key={index}>
                    {capital}
                  </span>
                ))}
              </p>
              <p>
                Population:
                <span className="info">{countryData.population}</span>
              </p>
            </div>
          </div>
        )}
      </div>
    </div>
  );

  async function search() {
    try {
      setCountryData(undefined);
      const res = await axios.get(COUNTRY_API_URL_START + countryName);
      if (res.status === 200) {
        console.log(res.data);
        setCountryData(res.data[0]);
        console.log(countryData);
        console.log(countryData?.capital);
        console.log(countryData?.continents);
      } else {
        console.log(res.status);
      }
    } catch {
      console.log("Something went wrong");
    }
  }
}

export default App;
