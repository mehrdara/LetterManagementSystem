using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
using Application.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Mapster;

namespace Application.Queries
{
    public record GetUserNamesQuery : IRequest<List<UserNameDto>>;
    public class GetUsersNamesHandler : IRequestHandler<GetUserNamesQuery, List<UserNameDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public GetUsersNamesHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<List<UserNameDto>> Handle(GetUserNamesQuery request, CancellationToken cancellationToken)
        {
            {
                var cacheKey = "UserNames";

                var cachedUsers = _cache.Get<List<UserNameDto>>(cacheKey);

                if (cachedUsers == null)
                {
                    var query = _unitOfWork.User
                        .GetAll()
                        .ProjectToType<UserNameDto>();

                    cachedUsers = await _unitOfWork.User.ToListAsync(query, cancellationToken);

                    _cache.Set(cacheKey, cachedUsers, TimeSpan.FromHours(1));

                }
                return cachedUsers;

            }

        }
    }
}