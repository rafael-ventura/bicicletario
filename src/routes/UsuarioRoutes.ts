import {Request, Response} from 'express';
import {IUser} from '@src/models/User';
import UserService from '@src/services/UserService';
import HttpStatusCodes from '@src/constants/HttpStatusCodes';

interface UserRequest extends Request {
  body: { user: IUser };
}

/**
 * @swagger
 * tags:
 *   name: Usuarios
 *   description: Gerenciamento de usuários.
 */

/**
 * @swagger
 * /usuarios:
 *   get:
 *     summary: Lista todos os usuários
 *     description: Retorna uma lista de todos os usuários registrados no sistema.
 *     tags:
 *       - Usuário
 *     responses:
 *       200:
 *         description: Lista de usuários.
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Usuario'
 *             example:
 *               - id: 1
 *                 nome: João
 *                 email: joao@example.com
 *               - id: 2
 *                 nome: Maria
 *                 email: maria@example.com
 *       404:
 *         description: Nenhum usuário encontrado.
 *         content:
 *           application/json:
 *             example:
 *               error: Não existem usuários registrados.
 */

async function getAll(req: Request, res: Response) {
  const users = await UserService.getAll();
  return res.status(HttpStatusCodes.OK).json(users);
}

/**
 * @swagger
 * /usuario:
 *   post:
 *     summary: Cria um novo usuário
 *     tags: [Usuario]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Usuario'
 *     responses:
 *       200:
 *         description: Usuário criado com sucesso
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Usuario'
 *       400:
 *         description: Requisição inválida
 *       500:
 *         description: Erro interno do servidor
 */
async function add(req: UserRequest, res: Response) {
  const {user} = req.body;
  await UserService.addOne(user);
  return res.status(HttpStatusCodes.CREATED).end();
}



async function update(req: UserRequest, res: Response) {
  const {user} = req.body;
  await UserService.updateOne(user);
  return res.status(HttpStatusCodes.OK).end();
}

/**
 * @swagger
 * /usuarios/{id}:
 *   delete:
 *     summary: Remove um usuário.
 *     tags: [Usuarios]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID do usuário.
 *     responses:
 *       200:
 *         description: Usuário removido com sucesso.
 *       404:
 *         description: Usuário não encontrado.
 */
async function delete_(req: Request, res: Response) {
  const id = +req.params.id;
  await UserService.delete(id);
  return res.status(HttpStatusCodes.OK).end();
}

export default {
  getAll,
  add,
  update,

  delete: delete_,
} as const;
