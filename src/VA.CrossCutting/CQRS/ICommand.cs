﻿namespace VA.CrossCutting.CQRS;

public interface ICommand : IBaseCommand;

public interface ICommand<out TResponse> : IBaseCommand;

public interface IBaseCommand;