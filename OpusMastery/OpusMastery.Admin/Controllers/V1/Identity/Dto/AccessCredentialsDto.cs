﻿namespace OpusMastery.Admin.Controllers.V1.Identity.Dto;

public class AccessCredentialsDto
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
    public required string TokenType { get; set; }
}