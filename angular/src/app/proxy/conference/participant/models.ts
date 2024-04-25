import type { TicketType } from './ticket-type.enum';
import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateParticipantDto {
  firstName: string;
  surname: string;
  emailAdress: string;
  phoneNumber: string;
  ticketType: TicketType;
}

export interface ParticipantDto extends AuditedEntityDto<string> {
  firstName?: string;
  surname?: string;
  emailAdress?: string;
  phoneNumber?: string;
  ticketType: TicketType;
}
