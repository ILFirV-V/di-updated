using System.Net;
using System.Text.Json;
using FractalPainting.Application.Fractals;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.Application.Actions;

public class KochFractalAction(KochPainter painter, JsonSerializerOptions jsonSerializerOptions) : IApiAction
{
    public string Endpoint => "/kochFractal";

    public string HttpMethod => "POST";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var figures = painter.Paint();
        JsonSerializer.Serialize(outputStream, figures, options: jsonSerializerOptions);
        return (int)HttpStatusCode.OK;
    }
}