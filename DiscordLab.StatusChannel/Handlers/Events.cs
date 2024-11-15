﻿using DiscordLab.Bot.API.Interfaces;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace DiscordLab.StatusChannel.Handlers;

public class Events : IRegisterable
{
    public void Init()
    {
        Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
        Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
        Exiled.Events.Handlers.Player.Verified += OnPlayerVerified;
        Exiled.Events.Handlers.Player.Left += OnPlayerLeave;
    }
    
    public void Unregister()
    {
        Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
        Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        Exiled.Events.Handlers.Player.Verified -= OnPlayerVerified;
        Exiled.Events.Handlers.Player.Left -= OnPlayerLeave;
    }
    
    private void OnWaitingForPlayers()
    {
        DiscordBot.Instance.SetStatusMessage();
    }
    
    private void OnRoundStarted()
    {
        DiscordBot.Instance.SetStatusMessage();
    }
    
    private void OnPlayerVerified(VerifiedEventArgs ev)
    {
        if(Round.InProgress) DiscordBot.Instance.SetStatusMessage();
    }
    
    private void OnPlayerLeave(LeftEventArgs ev)
    {
        if(Round.InProgress) DiscordBot.Instance.SetStatusMessage(Player.List.Where(p => p != ev.Player));
    }
}