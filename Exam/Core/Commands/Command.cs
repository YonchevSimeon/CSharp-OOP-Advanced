﻿namespace FestivalManager.Core.Commands
{
    using Contracts;

    public abstract class Command : ICommand
    {
        public abstract string Execute(params string[] args);
    }
}
