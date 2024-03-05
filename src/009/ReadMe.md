# Historical Weather

A [CSV of historical weather](./HistoricalWeather/open-meteo-53.60N113.28W614m.csv) from [open-meteo.com](https://open-meteo.com/en/docs/historical-weather-api/#hourly=temperature_2m,wind_speed_10m,wind_gusts_10m&timezone=auto) is supplied for parsing purposes. Here is the structure of the CSV data:

- The first line is a header for the location of the weather
- The second line is the location data
- The third line is blank
- The fourth line is a header for the weather information
- The remaining lines are weather data
- The final line is empty

And here is a short sample from the provided [data file](./HistoricalWeather/open-meteo-53.60N113.28W614m.csv).

| latitude | longitude  | elevation | utc_offset_seconds | timezone         | timezone_abbreviation |
|----------|------------|-----------|--------------------|------------------|-----------------------|
| 53.60281 | -113.27586 | 614.0     | -25200             | America/Edmonton | MST                   |

And for the weather details:

| time             | temperature_2m (°C) | wind_speed_10m (km/h) | wind_gusts_10m (km/h) |
|------------------|---------------------|-----------------------|-----------------------|
| 2024-01-30T00:00 | 3.7                 | 14.1                  | 23.0                  |
| 2024-01-30T01:00 | 4.7                 | 16.5                  | 25.9                  |
| 2024-01-30T02:00 | 5.3                 | 17.7                  | 32.0                  |


Examine the header lines and model appropriate classes with `Parse()` and `TryParse()` methods. Integrate the design with the [`WindChill`](./Code/WindChill.cs) class from earlier demos.

Create a page in a Blazor 8 application to report on the available historical data. Provide a custom component for calendar input to select a range of days (start/end) for the data.
