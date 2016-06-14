const PERMISSIONS_URL = 'permissions/';
const ROLES_URL       = 'roles/';

import {
   reduce
} from 'lodash';

let _$q, _HttpService, _HttpCacheService, _LoggerService;
export default class RoleService {
   constructor($q, HttpService, HttpCacheService, LoggerService) {
      'ngInject';
      _HttpService      = HttpService;
      _HttpCacheService = HttpCacheService;
      _LoggerService    = LoggerService;
      _$q               = $q;
   }

   getPermissions() {
      return _HttpCacheService.get(PERMISSIONS_URL).then((perm) => {
         return reduce(perm, (memo, permis) => {
            memo[permis.group] = memo[permis.group] || [];
            memo[permis.group].push(permis);
            return memo;
         },{});
      });
   }

   getRoles () {
      return _HttpCacheService.get(ROLES_URL);
   }

   saveRole(role) {
      if (role.id) {
         return _HttpService.put(`${ROLES_URL}/${role.id}`, role);
      } else {
         return _HttpService.post(ROLES_URL, role).then(_role => {
            _HttpCacheService.clearCache(ROLES_URL);
            return _role;
         });
      }
   }

   removeRole(role) {
      if (role.id) {
         const additionalUrl = ROLES_URL + role.id;
         _HttpCacheService.clearCache(ROLES_URL);
         return _HttpService.remove(additionalUrl, role);
      } else {
         _LoggerService.debug('Can\'t remove role', role);
         return _$q.reject();
      }
   }
}
