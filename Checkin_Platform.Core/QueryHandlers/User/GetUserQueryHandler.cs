﻿using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.User;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var userList = _unitOfWork.User.ToList();
            var userDtoList = new List<UserDto>();
            foreach (var item in userList)
            {
                userDtoList.Add(new UserDto
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Role = item.Role,
                    Department = item.Department,
                    Group = item.Group,
                    Year = item.Year,
                    ScheduleReservations = item.ScheduleReservations
                });
            }
            return userDtoList;
        }
    }