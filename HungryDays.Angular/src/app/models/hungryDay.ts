import { HungryItem } from "./hungryItem";

export interface HungryDay {
    id: number;
    day: string;
    diner: string;
    hungryItems: HungryItem[];
}