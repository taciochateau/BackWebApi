import { Component } from '@angular/core';
import { ClientService } from '../../services/client.service';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent {
  client = {
    companyName: '',
    size: 'Small',
  };

  constructor(private clientService: ClientService) {}

  onSubmit(): void {
    this.clientService.addClient(this.client).subscribe(() => {
      alert('Client added successfully!');
      this.client = { companyName: '', size: 'Small' }; // Reset form
    });
  }
}
