export interface MoneyAccount {
  name: string;
  excludeFromTotal: boolean;
  currency: string;
  initialBalance: number;
  currentBalance: number;
}
