import { mapEnumToOptions } from '@abp/ng.core';

export enum TicketType {
  Concessionary = 0,
  Normal = 1,
  Vip = 2,
}

export const ticketTypeOptions = mapEnumToOptions(TicketType);
