import utils  from './../../utils.js';
let MIN_EVENTS_NUM = 3;
let MAX_EVENTS_NUM = 100;
import {
   clone,
   split,
   isEqual,
   remove,
   assign
} from 'lodash';
import template from './events.directive.html';
import './events.scss';
export default class EventsDirective {
   constructor() {
      this.restrict   = 'E';
      this.template   = template;
      this.scope      = {
         type            : '@',
         events          : '=',
         save            : '=',
         remove          : '=',
         getEventsByDate : '=',
         candidateId     : '=',
         userId          : '=',
         source          : '@',
         vacancies       : '=',
         candidates      : '=',
         eventTypes      : '=',
         responsibles    : '=',
         selectedDate    : '=',
         userColor       : '='
      };
      this.controller = EventsController;
   }
   static createInstance() {
      'ngInject';
      EventsDirective.instance = new EventsDirective();
      return EventsDirective.instance;
   }
}

function EventsController(
   $scope,
   $translate,
   $timeout,
   $filter,
   VacancyService,
   CandidateService,
   UserService,
   ThesaurusService,
   UserDialogService) {
   'ngInject';
   const vm               = $scope;
   vm.event               = {};
   vm.saveEvent           = saveEvent;
   vm.showAddEventDialog  = showAddEventDialog;
   vm.showEditEventDialog = showEditEventDialog;
   vm.getEvents           = getEvents;
   vm.currentEvents       = [];
   vm.limit               = vm.source === 'calendar' ? MIN_EVENTS_NUM : MAX_EVENTS_NUM;
   vm.$on('onDblclick', function fromParent(event, obj) {
      if (vm.selectedDate === obj.date && vm.source === 'calendar') {
         vm.currentDate = obj.date;
         showAddEventDialog();
      }
   });

   function saveEvent() {
      vm.save(vm.event).then((event) => {
         if (vm.eventForEdit && event.eventDate === vm.eventForEdit.eventDate) {
            remove(vm.events, {id: vm.eventForEdit.id, eventDate: vm.eventForEdit.eventDate});
            vm.events.push(event);
         }  else if (vm.eventForEdit) {
            remove(vm.events, {id: vm.eventForEdit.id, eventDate: vm.eventForEdit.eventDate});
         }
      });
   }

   function getEvents(date) {
      if (date && vm.source === 'user') {
         vm.getEventsByDate(date).then((e) => {
            vm.currentEvents.length = 0;
            vm.currentEvents.push.apply(vm.currentEvents, e);
         });
      } else {
         vm.currentEvents.length = 0;
      }
   }

   let defaultModalScope = {
      searchResponsible   : UserService.autocomplete,
      getFullName         : UserService.getFullName,
      searchVacancy       : VacancyService.autocomplete,
      searchCandidate     : CandidateService.autocomplete
   };
   function showAddEventDialog() {
      let typeOfModalDialog = 'list-with-input';
      if (vm.source === 'calendar') {
         typeOfModalDialog = 'form-only';
      }
      vm.event = {};
      vm.currentEvents.length = 0;
      if (vm.userId) {
         vm.event.responsibleId = vm.userId;
      }
      if (vm.candidateId) {
         vm.event.candidateId = vm.candidateId;
      }
      if (vm.currentDate) {
         let date = new Date(vm.currentDate.valueOf() - vm.currentDate.getTimezoneOffset() * 60000);
         let convertedDate = utils.formatDateTimeFromServer(date.toISOString());
         vm.event.eventDate = convertedDate;
      }

      let scope = assign(defaultModalScope, {
         type                : typeOfModalDialog,
         eventTypes          : vm.eventTypes,
         vacancies           : vm.vacancies,
         candidates          : vm.candidates,
         events              : vm.currentEvents,
         event               : vm.event,
         getEvents           : vm.getEvents,
         source              : vm.source
      });
      let buttons = [
         {
            name: $translate.instant('COMMON.CANCEL')
         },
         {
            name: $translate.instant('COMMON.APLY'),
            func: vm.saveEvent,
            needValidate: true
         }
      ];
      UserDialogService.dialog($translate.instant('COMMON.EVENTS'), template, buttons, scope);

      let eventDate = '';

      $scope.$watch('event.eventDate', function watch() {
         let newEventDate = split(vm.event.eventDate, ' ');
         if (eventDate) {
            let clonedTrimedEventDate = split(eventDate, ' ');
            if (!isEqual(newEventDate[0], clonedTrimedEventDate[0])) {
               getEvents(vm.event.eventDate);
            }
         }
         eventDate = vm.event.eventDate;
      });
   }

   function showEditEventDialog(currentEvent) {
      vm.eventForEdit = clone(currentEvent);
      vm.event = clone(currentEvent);

      let scope = assign(defaultModalScope, {
         type                : 'form-only',
         eventTypes          : vm.eventTypes,
         vacancies           : vm.vacancies,
         candidates          : vm.candidates,
         event               : vm.event,
         source              : vm.source
      });

      let buttons = [
         {
            name: $translate.instant('COMMON.CANCEL'),
            func: vm.returnEventToList
         },
         {
            name: $translate.instant('COMMON.APLY'),
            func: vm.saveEvent,
            needValidate: true
         }
      ];
      UserDialogService.dialog($translate.instant('COMMON.EVENTS'), template, buttons, scope);
   }
}
