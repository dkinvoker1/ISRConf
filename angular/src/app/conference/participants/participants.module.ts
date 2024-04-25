import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';

import { ParticipantsRoutingModule } from './participants-routing.module';
import { ParticipantsComponent } from './participants.component';


@NgModule({
  declarations: [
    ParticipantsComponent
  ],
  imports: [
    SharedModule,
    ParticipantsRoutingModule
  ]
})
export class ParticipantsModule { }
