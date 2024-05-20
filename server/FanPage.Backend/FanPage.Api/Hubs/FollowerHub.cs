using AutoMapper;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.SignalR;

namespace FanPage.Api.Hubs;

public class FollowerHub : Hub
{
    private readonly IFollower _follower;

    private readonly IHubContext<FollowerHub> _hubContext;

    private readonly IMapper _mapper;

    public FollowerHub(IFollower follower, IHubContext<FollowerHub> hubContext, IMapper mapper)
    {
        _follower = follower;
        _hubContext = hubContext;
        _mapper = mapper;
    }

    public async Task UserFollower(string userName, int page)
    {
        var result = await _follower.UserFollower(userName, page);
        await Clients.All.SendAsync("UserFollower", result);
    }
    public async Task FollowerList(string userName,int page)
    {
        var result = await _follower.FollowerList(userName, page);
        await Clients.All.SendAsync("FollowerList", result);
    }

    public async Task Subscribe(string username)
    {
        var request = Context.GetHttpContext().Request;
        await _follower.Subscribe(request, username);
        await Clients.All.SendAsync("Subscribe", username);
    }

    public async Task Unsubscribe(string username)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _follower.Unsubscribe(request, username);
        await Clients.All.SendAsync("Unsubscribe", result);
    }
}