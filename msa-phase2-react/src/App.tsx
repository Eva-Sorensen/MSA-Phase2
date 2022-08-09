import axios from "axios";
import React, { useState } from "react";
import "./App.css";
import { CountryData } from "./types";
import { MapContainer, Marker, Popup, TileLayer } from "react-leaflet";
import {
  Divider,
  Stack,
  Card,
  Chip,
  IconButton,
  TextField,
  Grid,
  Avatar,
  Typography,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";

function App() {
  const [countryName, setCountryName] = useState("");
  const [countryData, setCountryData] = useState<undefined | CountryData>(
    undefined
  );
  const [countryState, setCountryState] = useState<
    "No Country Selected" | "Loading" | "Country Not Found"
  >("No Country Selected");

  const COUNTRY_API_URL_START = "https://restcountries.com/v3.1/name/";

  return (
    <Grid
      container
      direction="column"
      justifyContent="flex-start"
      alignItems="center"
      spacing={4}
      sx={{ p: 4 }}
    >
      <Grid item>
        <Typography variant="h3">COUNTRY FACTS</Typography>
      </Grid>

      <Grid item>
        <TextField
          id="search-bar"
          className="text"
          value={countryName}
          onChange={(prop: any) => {
            setCountryName(prop.target.value);
          }}
          label="Enter a Country Name..."
          variant="outlined"
          placeholder="Search..."
          size="small"
        />
        <IconButton
          aria-label="search"
          onClick={() => {
            search();
          }}
        >
          <SearchIcon style={{ fill: "blue" }} />
        </IconButton>
      </Grid>

      {countryData === undefined ? (
        <Grid item>
          <Card raised={true}>
            <Typography
              variant="h5"
              sx={{
                p: 4,
                color:
                  (countryState as string) === "Country Not Found"
                    ? "red"
                    : "black",
              }}
            >
              {countryState}
            </Typography>{" "}
          </Card>
        </Grid>
      ) : (
        <Grid item>
          <Card raised={true}>
            <Stack
              direction="row"
              justifyContent="center"
              alignItems="center"
              spacing={4}
              sx={{ p: 2 }}
            >
              <Avatar
                alt={countryName + "'s flag"}
                src={countryData.flags.png}
              />
              <Typography variant="h5">
                {countryData.name.official}{" "}
                {countryData.name.official === countryData.name.common
                  ? ""
                  : "(" + countryData.name.common + ")"}
              </Typography>
            </Stack>

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
                <Popup>{countryData.name.common}</Popup>
              </Marker>
            </MapContainer>

            <Stack
              direction="row"
              justifyContent="center"
              alignItems="center"
              spacing={4}
              sx={{ p: 2 }}
              divider={<Divider orientation="vertical" flexItem />}
            >
              <Stack
                direction="row"
                justifyContent="center"
                alignItems="center"
                spacing={1}
              >
                <Typography variant="subtitle1">
                  {countryData.continents.length === 1
                    ? "Continent:"
                    : "Continents:"}
                </Typography>
                {countryData.continents.map((continent, index) => (
                  <Chip label={continent} variant="outlined" key={index} />
                ))}
              </Stack>
              <Stack
                direction="row"
                justifyContent="center"
                alignItems="center"
                spacing={1}
              >
                <Typography variant="subtitle1">
                  {countryData.capital.length === 1 ? "Capital:" : "Capitals:"}
                </Typography>
                {countryData.capital.map((capital, index) => (
                  <Chip label={capital} variant="outlined" key={index} />
                ))}
              </Stack>
            </Stack>
          </Card>
        </Grid>
      )}
    </Grid>
  );

  async function search() {
    try {
      setCountryState("Loading");
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
      setCountryState("Country Not Found");
    }
  }
}

export default App;
