// TODO: Implementar métodos de acesso a dados
/* eslint-disable @typescript-eslint/no-unused-vars */
import { IUser } from '@src/models/User';

class UserRepo {
  static async getAll(): Promise<IUser[]> {
    // Implementação removida
    return Promise.resolve([]);
  }

  static async add(user: IUser): Promise<void> {
    // Implementação removida
    return Promise.resolve();
  }

  static async update(user: IUser): Promise<void> {
    // Implementação removida
    return Promise.resolve();
  }

  static async delete(id: number): Promise<void> {
    // Implementação removida
    return Promise.resolve();
  }

  static async persists(id: number): Promise<boolean> {
    // Implementação removida
    return Promise.resolve(false);
  }
}

export default UserRepo;
