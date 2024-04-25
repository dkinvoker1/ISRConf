import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ParticipantService, ParticipantDto, ticketTypeOptions } from '@proxy/conference/participant';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-participants',
  templateUrl: './participants.component.html',
  styleUrl: './participants.component.scss',
  providers: [ListService],
})
export class ParticipantsComponent implements OnInit {
  participant = { items: [], totalCount: 0 } as PagedResultDto<ParticipantDto>;

  selectedParticipant = {} as ParticipantDto;

  form: FormGroup;

  ticketTypes = ticketTypeOptions;
  isModalOpen = false;

  constructor(public readonly list:
    ListService,
    private participantService: ParticipantService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) { }

  ngOnInit() {
    const participantStreamCreator = (query) => this.participantService.getList(query);

    this.list.hookToQuery(participantStreamCreator).subscribe((response) => {
      this.participant = response;
    });
  }

  createParticipant() {
    this.selectedParticipant = {} as ParticipantDto;
    this.buildForm();
    this.isModalOpen = true;
  }


  editParticipant(id: string) {
    this.participantService.get(id).subscribe((book) => {
      this.selectedParticipant = book;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      firstName: [this.selectedParticipant.firstName || '', Validators.required],
      surname: [this.selectedParticipant.surname || '', Validators.required],
      emailAdress: [this.selectedParticipant.emailAdress || '', Validators.required],
      phoneNumber: [this.selectedParticipant.phoneNumber || '', Validators.required],
      ticketType: [this.selectedParticipant.ticketType || null, Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedParticipant.id
      ? this.participantService.update(this.selectedParticipant.id, this.form.value)
      : this.participantService.create(this.form.value);


    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.participantService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
