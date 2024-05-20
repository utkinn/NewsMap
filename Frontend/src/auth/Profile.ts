export interface Profile {
    firstName: string;
    lastName: string;
    email: string;
    subscribedToUpdateNews: boolean;
    notifications: {
        push: boolean;
        nearbyNews: boolean;
        importantNews: boolean;
        emergencyNews: boolean;
    };
    isAdmin: boolean;
}
