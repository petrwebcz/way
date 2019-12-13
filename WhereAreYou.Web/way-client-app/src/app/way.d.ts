//// ..\..\Core\Entity\AdvertPosition.cs
//    export class AdvertPosition {
//        user: User;
//        location: Location;
//    }

//    // ..\..\Core\Entity\Location.cs
//    export class Location {
//        latitude: number;
//        longitude: number;
//    }

//    // ..\..\Core\Entity\Position.cs
//    export class Position {
//        user: User;
//        location: Location;

//        constructor() { }
//    }

//    // ..\..\Core\Entity\Room.cs
//    export class Room {

//        id: string;
//        name: string;
//        created: string;
//        lastUpdated: string;
//        positions: Position[];
//        inviteUrl: string;
//        inviteHash: string;
//        centerPoint: Location;

//        public constructor(init?: Partial<Room>) {
//            Object.assign(this, init);
//        }
//    }

//    // ..\..\Core\Entity\User.cs 
//    export class User {
//        id: string;
//        nickname: string;
//        roomInviteHash: string;

//    }

//    // ..\..\Core\Requests\CreateRoom.cs
//    export class CreateRoom {
//        name: string;
//    }

//    // ..\..\Core\Requests\EnterTheRoom.cs
//    export class EnterTheRoom {
//        nickname: string;
//        inviteHash: string;
//        inviteUrl: string;

//        public constructor(init?: Partial<EnterTheRoom>) {
//            Object.assign(this, init);
//        }
//    }

//    // ..\..\Core\Requests\UpdatePosition.cs
//    export class UpdatePosition {
//        location: Location;

//        public constructor(init?: Partial<UpdatePosition>) {
//            Object.assign(this, init);
//        }
//    }

//    // ..\..\Core\Responses\CreatedRoom.cs
//    export class CreatedRoom {
//        inviteUrl: string;
//        inviteHash: string;
//        name: string;

//        public constructor(init?: Partial<CreatedRoom>) {
//            Object.assign(this, init);
//        }
//    }

//    // ..\..\Core\Responses\Token.cs
//    export class Token {
//        jwt: string;

//        public constructor(init?: Partial<>) {
//            Object.assign(this, init);
//        }
//    }
