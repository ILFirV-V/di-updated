﻿using System.Net;
using System.Text.Json;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.Application.Actions;

public class GetImageSettingsAction(IImageSettingsProvider dependency) : IApiAction
{
    public string Endpoint => "/settings";
        
    public string HttpMethod => "GET";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var settings = dependency?.ImageSettings;
        JsonSerializer.Serialize(outputStream, settings);
        return (int)HttpStatusCode.OK;
    }
}