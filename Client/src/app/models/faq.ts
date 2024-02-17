import { User } from "./user";

export interface Faq {
    id: number,
    question: string,
    answer: string,
    user: User
}