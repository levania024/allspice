import { Account } from "./Account.js"

export class Recipe {
    constructor(data) {
        this.id = data.id
        this.img = data.img
        this.title = data.title
        this.category = data.category
        this.creatorId = data.creatorId
        this.instructions = data.instructions
        this.updateAt = new Date(data.updateAt)
        this.createdAt = new Date(data.createdAt)
        this.creator = data.creator ? new Account(data.creator) : null
    }
}

// const data ={
//     "id": 1,
//     "createdAt": "2024-10-17T21:26:55",
//     "updatedAt": "2024-10-17T21:26:55",
//     "title": "Mark's Mac n Cheese",
//     "instructions": "Take your pasta and cook it, then add the cheese. Boom, Mac and Cheese.",
//     "img": "https://images.unsplash.com/photo-1612892010343-983bfd063dc5?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8bWFjYXJvbmklMjBhbmQlMjBjaGVlc2V8ZW58MHx8MHx8fDA%3D",
//     "category": "snack",
//     "creatorId": "66f60a1757576e4e5334b9e1",
//     "creator": {
//       "id": "66f60a1757576e4e5334b9e1",
//       "name": "jaciboh298@skrak.com",
//       "picture": "https://s.gravatar.com/avatar/db0c7bcb6be2f7a75109ef314ed2e88f?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fja.png"
//     }
//   }