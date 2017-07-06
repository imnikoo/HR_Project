import mainTemplate             from './views/main.view.html';
import homeTemplate             from './views/home/home.view.html';
import candidatesTemplate       from './views/candidates/candidates.view.html';
import candidateTemplate        from './views/candidate/candidate.view.html';
import vacanciesTemplate        from './views/vacancies/vacancies.list.html';
import vacancyEditTemplate      from './views/vacancy/vacancy.edit.html';
import settingsTemplate         from './views/settings/settings.view.html';
import thesaurusesTemplate      from './views/settings/thesauruses/thesauruses.view.html';
import profileTemplate          from './views/settings/profile/profile.view.html';
import profileEditTemplate      from './views/settings/profile/profileEdit.view.html';
import membersTemplate          from './views/settings/members/members.view.html';
import rolesTemplate            from './views/settings/roles/roles.view.html';
import vacancyViewTemplate      from './views/vacancy.profile/vacancy.view.html';
import candidateProfileTemplate from './views/candidate.profile/candidate.profile.html';
import loaderTemplate           from './views/loading/loading.view.html';
import loginTemplate            from './views/login/login.view.html';
import calendarTemplate         from './views/calendar/calendar.html';
import reportsTemplate          from './views/reports/reports.html';
import recruitingFunnelTemplate from './views/reports/recruiting-funnel/recruiting.funnel.view.html';
import usersReportTemplate      from './views/reports/users-report/users.report.view.html';
import vacanciesReportTemplate  from './views/reports/vacancies-report/vacancies.report.view.html';
import recoverTemplate          from './views/recoverAccount/recover.view.html';
import candidatesReportTemplate from './views/reports/candidates-report/candidates.report.view.html';

import homeController             from './views/home/home.controller';
import candidatesController       from './views/candidates/candidates.controller';
import candidateController        from './views/candidate/candidate.controller';
import vacanciesController        from './views/vacancies/vacancies.list.controller';
import vacancyEditController      from './views/vacancy/vacancy.edit.controller';
import settingsController         from './views/settings/settings.controller';
import thesaurusesController      from './views/settings/thesauruses/thesauruses.controller';
import profileController          from './views/settings/profile/profile.controller';
import membersController          from './views/settings/members/members.controller';
import rolesController            from './views/settings/roles/roles.controller';
import vacancyViewController      from './views/vacancy.profile/vacancy.view.controller';
import candidateProfileController from './views/candidate.profile/candidate.profile.controller';
import loginController            from './views/login/login.controller';
import calendarController         from './views/calendar/calendar.controller';
import reportsController          from './views/reports/reports.controller';
import recruitingFunnelController from './views/reports/recruiting-funnel/recruiting.funnel.controller';
import usersReportController      from './views/reports/users-report/users.report.controller';
import vacanciesReportController  from './views/reports/vacancies-report/vacancies.report.controller';
import recoverController          from './views/recoverAccount/recover.controller.js';
import candidatesReportController from './views/reports/candidates-report/candidates.report.controller.js';

import translationsEn from './translations/translations-en.json';
import translationsRu from './translations/translations-ru.json';

import context from './context';

export default function _config(
   $stateProvider,
   $httpProvider,
   $urlRouterProvider,
   $locationProvider,
   $translateProvider,
   $compileProvider,
   LoggerServiceProvider,
   HttpServiceProvider,
   ExportServiceProvider
) {
   'ngInject';
   //this case must be before $stateProvider
   $urlRouterProvider.otherwise($injector => {
      let $state = $injector.get('$state');
      $state.go('home');
   })
      .when('/vacancies','/vacancies/search')
      .when('/candidates', 'candidates/search')
      .when('/settings/roles', '/bot')
      .when('/candidates/profile/', '/bot')
      .when('/vacancies/view/', '/bot');

   $stateProvider
      .state('main', {
         template: mainTemplate,
         abstract: true
      })
      .state('home', {
         url: '/bot',
         template: homeTemplate,
         controller: homeController,
         parent: 'main'
      })
      .state('candidates', {
         parent: 'main',
         url: '/candidates',
         template: '<ui-view/>'
      })
      .state('candidates.search', {
         url: '/search',
         template: candidatesTemplate,
         controller: candidatesController,
         params: {
            candidateIds: null,
            vacancyIdToGoBack: null,
            candidatePredicate: null
         }
      })
      .state('vacancies', {
         parent: 'main',
         url: '/vacancies',
         template: '<ui-view/>'
      })
      .state('vacancies.search', {
         url: '/search',
         template: vacanciesTemplate,
         controller: vacanciesController,
         params: {
            vacanciesIds: null,
            candidateIdToGoBack: null,
            vacancyPredicate: null
         }
      })
      .state('vacancyView', {
         url: '/view/:vacancyId',
         template: vacancyViewTemplate,
         controller: vacancyViewController,
         params: {
            candidatesIds: [],
            vacancyId: null,
            vacancyGoBack: null
         },
         parent: 'vacancies'
      })
      .state('candidate', {
         url: '/edit/:candidateId',
         template: candidateTemplate,
         controller: candidateController,
         params: {
            candidateId: null,
            vacancyIdToGoBack: null,
            duplicates: null,
            notSavedCandidate : null
         },
         parent: 'candidates'
      })
      .state('candidateProfile', {
         url: '/profile/:candidateId',
         template: candidateProfileTemplate,
         controller: candidateProfileController,
         params: {
            vacancies: [],
            candidateId: null,
            vacancyGoBack: null
         },
         parent: 'candidates'
      })
      .state('vacancyEdit', {
         url: '/edit/:vacancyId',
         template: vacancyEditTemplate,
         controller: vacancyEditController,
         params: {
            vacancyId: null
         },
         parent: 'vacancies'
      })
      .state('calendar', {
         url: '/calendar',
         template: calendarTemplate,
         controller: calendarController,
         parent: 'main'
      })
      .state('reports', {
         url: '/reports',
         template: reportsTemplate,
         controller: reportsController,
         parent: 'main'
      })
      .state('recruitingFunnel', {
         url: '/recruitingFunnel',
         parent: 'reports',
         template: recruitingFunnelTemplate,
         controller: recruitingFunnelController,
         params: {
            vacancyGoBack: null
         }
      })
      .state('usersReport', {
         url: '/usersReport',
         parent: 'reports',
         template: usersReportTemplate,
         controller: usersReportController
      })
      .state('vacanciesReport', {
         url: '/vacanciesReport',
         parent: 'reports',
         template: vacanciesReportTemplate,
         controller: vacanciesReportController
      })
      .state('candidatesReport', {
         url: '/candidatesReport',
         parent: 'reports',
         template: candidatesReportTemplate,
         controller: candidatesReportController
      })
      .state('settings', {
         url: '/settings',
         template: settingsTemplate,
         controller: settingsController,
         data: {
            asEdit: false,
            showButtons: false
         },
         parent: 'main'
      })
      .state('profile', {
         url: '/profile',
         parent: 'settings',
         template: profileTemplate,
         controller: profileController,
         data: {
            showButtons: true
         }
      })
      .state('profile.edit', {
         url: '/edit',
         parent: 'profile',
         template: profileEditTemplate,
         data: { asEdit: true }
      })
      .state('members', {
         url: '/members',
         parent: 'settings',
         template: membersTemplate,
         controller: membersController,
         data: { asEdit: true }
      })
      .state('roles', {
         url: '/roles',
         parent: 'settings',
         template: rolesTemplate,
         controller: rolesController,
         data: { asEdit: true }
      })
      .state('thesauruses', {
         url: '/recruiting',
         parent: 'settings',
         template: thesaurusesTemplate,
         controller: thesaurusesController
      })
      .state('login', {
         url: '/login',
         template: loginTemplate,
         controller: loginController
      })
      .state('loading', {
         url: '/loading',
         template: loaderTemplate
      })
      .state('recoverAccount', {
         url: '/recover',
         template: recoverTemplate,
         controller: recoverController
      });

   $locationProvider.html5Mode({
      enabled: true,
      requireBase: false
   });

   $translateProvider
      .useSanitizeValueStrategy('sanitize')
      .translations('en', translationsEn)
      .translations('ru', translationsRu)
      .preferredLanguage(context.defaultLang);

   $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|file|skype|tel):/);

   $httpProvider.interceptors.push('authInterceptor');

   LoggerServiceProvider.changeLogLevel(context.logLevel);
   HttpServiceProvider.changeApiUrl(context.serverUrl + context.apiSuffix);
   ExportServiceProvider.changeApiUrl(context.serverUrl + context.apiSuffix);
}
