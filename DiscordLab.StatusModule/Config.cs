﻿using System.ComponentModel;
using Exiled.API.Interfaces;

namespace DiscordLab.StatusModule;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;
    [Description("The channel ID where the status message will be sent.")]
    public ulong ChannelId { get; set; } = new ();
}