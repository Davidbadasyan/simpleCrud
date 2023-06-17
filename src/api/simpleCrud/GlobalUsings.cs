// Global using directives

global using Autofac;
global using Autofac.Extensions.DependencyInjection;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using simpleCrud.Application.DTOs;
global using simpleCrud.Application.Mappings;
global using simpleCrud.Application.UseCases.Clients.Commands;
global using simpleCrud.Application.UseCases.Clients.Queries;
global using simpleCrud.AutofacModules;
global using simpleCrud.Domain.AggregatesModel.ClientAggregate;
global using simpleCrud.Domain.Exceptions;
global using simpleCrud.Infrastructure.Behaviours;
global using simpleCrud.Infrastructure.DbContexts;
global using simpleCrud.Infrastructure.Repositories.Clients;
global using simpleCrud.Middlewares;
global using System.Net;
global using System.Reflection;
global using System.Text.Json;
global using AppContext = simpleCrud.Infrastructure.DbContexts.AppContext;