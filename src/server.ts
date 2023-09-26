/**
 * Setup express server.
 */

import cookieParser from 'cookie-parser';
import morgan from 'morgan';
import express, {Request, Response} from 'express';
import 'express-async-errors';


import BaseRouter from '@src/routes/api';
import Paths from '@src/constants/Paths';

import EnvVars from '@src/constants/EnvVars';
import HttpStatusCodes from '@src/constants/HttpStatusCodes';
import { serve, setup } from '@src/other/Swagger';

import {RouteError} from '@src/other/classes';


// **** Variables **** //

const app = express();


// **** Setup **** //

// Middlewares basicos
app.use(express.json());
app.use(express.urlencoded({extended: true}));
app.use(cookieParser(EnvVars.CookieProps.Secret));

// Biblioteca/Middleware de logs
app.use(morgan('dev'));

// Swagger
// eslint-disable-next-line @typescript-eslint/no-unsafe-argument
app.use('/api-docs', serve, setup);

// Adiciona o caminho da API
app.use(Paths.Base, BaseRouter);

// Tratamento de erro do Servidor.
app.use((err: Error, _: Request, res: Response) => {
  let status = HttpStatusCodes.INTERNAL_SERVER_ERROR; // 500
  let message = 'Algo deu errado!';

  if (err instanceof RouteError) {
    status = err.status;
    message = err.message;
  }

  return res.status(status).json({error: message});
});

// **** Export default **** //

export default app;
