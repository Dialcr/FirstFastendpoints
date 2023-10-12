using FastEndpoints;


namespace FisrtFastEnpointsExample.Dto;

public class NewRequest
{
    [FromHeader]
    public string name { get; set; }
}