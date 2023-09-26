/**
 * Pre-start is where we want to place things that must run BEFORE the express 
 * server is started. This is useful for environment variables, command-line 
 * arguments, and cron-jobs.
 */

// NOTE: DO NOT IMPORT ANY SOURCE CODE HERE

import path from 'path';
import dotenv from 'dotenv';

// Carregar as variáveis de ambiente do arquivo .env
const result = dotenv.config({
  path: path.join(__dirname, '../env/development.env'),
});

// Checar se houve erro ao carregar as variáveis de ambiente
if (result.error) {
  throw result.error;
}

console.log('Variáveis de Ambiente Carregadas!');
