﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMvvm.Model.Entities;
public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary);