import { Component } from '@angular/core';
import { ChatService } from './chat.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'socket-client';

  constructor(private cs: ChatService) {
    cs.messages.subscribe(response => {
      if (response) {
        console.log("Received from Server: " + response);
      }
    });
  }

  sendMessage() {
    this.cs.messages.next("Message from client...");
  }
}
