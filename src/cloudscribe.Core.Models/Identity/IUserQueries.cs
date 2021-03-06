﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2014-08-18
// Last Modified:			2016-05-12
// 

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace cloudscribe.Core.Models
{
    public interface IUserQueries
    {
        
        Task<bool> LoginExistsInDB(
            Guid siteId, 
            string loginName,
            CancellationToken cancellationToken = default(CancellationToken));
        
        Task<bool> EmailExistsInDB(
            Guid siteId,
            Guid userId,
            string email,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> EmailExistsInDB(
            Guid siteId,
            string email,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<ISiteUser> Fetch(
            Guid siteId,
            Guid userId,
            CancellationToken cancellationToken = default(CancellationToken));
        
        Task<ISiteUser> Fetch(
            Guid siteId,
            string email,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<ISiteUser> FetchByLoginName(
            Guid siteId,
            string userName,
            bool allowEmailFallback,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<IUserInfo>> GetByIPAddress(
            Guid siteId,
            string ipv4Address,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<IUserInfo>> GetCrossSiteUserListByEmail(
            string email,
            CancellationToken cancellationToken = default(CancellationToken));



        Task<List<IUserInfo>> GetPage(
            Guid siteId,
            int pageNumber,
            int pageSize,
            string userNameBeginsWith,
            int sortMode,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountUsers(
            Guid siteId,
            string userNameBeginsWith,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<IUserInfo>> GetNotApprovedUsers(
            Guid siteId,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountNotApprovedUsers(
            Guid siteId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<IUserInfo>> GetPageUnconfirmedEmailUsers(
            Guid siteId,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountUnconfirmedEmail(
            Guid siteId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<IUserInfo>> GetPageUnconfirmedPhoneUsers(
            Guid siteId,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountUnconfirmedPhone(
            Guid siteId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<IUserInfo>> GetPageLockedByAdmin(
            Guid siteId,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountLockedByAdmin(
            Guid siteId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<IUserInfo>> GetPageFutureLockoutEndDate(
            Guid siteId,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountFutureLockoutEndDate(
            Guid siteGuid,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<IUserInfo>> GetUserAdminSearchPage(
            Guid siteId,
            int pageNumber,
            int pageSize,
            string searchInput,
            int sortMode,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountUsersForAdminSearch(
            Guid siteId,
            string searchInput,
            CancellationToken cancellationToken = default(CancellationToken));
        
        Task<string> GetUserNameFromEmail(
            Guid siteId,
            string email,
            CancellationToken cancellationToken = default(CancellationToken));
        
        

        Task<bool> LoginIsAvailable(
            Guid siteId,
            Guid userId,
            string loginName,
            CancellationToken cancellationToken = default(CancellationToken));

        //roles

        Task<int> CountOfRoles(
            Guid siteId,
            string searchInput,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> RoleExists(
            Guid siteId,
            string roleName,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<ISiteRole> FetchRole(
            Guid roleId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<ISiteRole> FetchRole(
            Guid siteId,
            string roleName,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<ISiteRole>> GetRolesBySite(
            Guid siteId,
            string searchInput,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<string>> GetUserRoles(
            Guid siteId,
            Guid userId,
            CancellationToken cancellationToken = default(CancellationToken));

        //IList<ISiteRole> GetRolesUserIsNotIn(int siteId, int userId);
        Task<IList<ISiteUser>> GetUsersInRole(
            Guid siteId,
            string roleName,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<IUserInfo>> GetUsersInRole(
            Guid siteId,
            Guid roleId,
            string searchInput,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<IUserInfo>> GetUsersNotInRole(
            Guid siteId,
            Guid roleId,
            string searchInput,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountUsersInRole(
            Guid siteId,
            Guid roleId,
            string searchInput,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountUsersNotInRole(
            Guid siteId,
            Guid roleId,
            string searchInput,
            CancellationToken cancellationToken = default(CancellationToken));

        // claims

        Task<IList<IUserClaim>> GetClaimsByUser(
            Guid siteId,
            Guid userId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<ISiteUser>> GetUsersForClaim(
            Guid siteId,
            string claimType,
            string claimValue,
            CancellationToken cancellationToken = default(CancellationToken));

        // logins

        Task<IUserLogin> FindLogin(
            Guid siteId,
            string loginProvider,
            string providerKey,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<IUserLogin>> GetLoginsByUser(
            Guid siteId,
            Guid userId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IUserLocation> FetchLocationByUserAndIpv4Address(
            Guid userId,
            long ipv4AddressAsLong,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountUserLocationsByUser(
            Guid userId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<IUserLocation>> GetUserLocationsByUser(
            Guid userId,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default(CancellationToken));

    }
}
