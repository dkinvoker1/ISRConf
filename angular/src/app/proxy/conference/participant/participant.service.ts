import type { CreateUpdateParticipantDto, ParticipantDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ParticipantService {
  apiName = 'Default';
  

  create = (newParticipantDto: CreateUpdateParticipantDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ParticipantDto>({
      method: 'POST',
      url: '/api/app/participant',
      body: newParticipantDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/participant/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ParticipantDto>({
      method: 'GET',
      url: `/api/app/participant/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ParticipantDto>>({
      method: 'GET',
      url: '/api/app/participant',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, newParticipantDto: CreateUpdateParticipantDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ParticipantDto>({
      method: 'PUT',
      url: `/api/app/participant/${id}`,
      body: newParticipantDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
