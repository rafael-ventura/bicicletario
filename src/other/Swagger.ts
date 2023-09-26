/* eslint-disable @typescript-eslint/no-unsafe-member-access,@typescript-eslint/no-unsafe-call */
import swaggerJsDoc from 'swagger-jsdoc';
import swaggerUi, { SwaggerUiOptions } from 'swagger-ui-express';

const options = {
  definition: {
    openapi: '3.0.0',
    info: {
      title: 'Bicicletario API',
      version: '1.0.0',
      description: 'Documentação da API do Sistema de Bicicletário',
    },
    servers: [
      {
        url: 'http://localhost:3000/api',
        description: 'Servidor Local',
      },
    ],
  },
  apis: ['./src/routes/*.ts', './src/swaggerSchemas/*.ts'],

};

// eslint-disable-next-line @typescript-eslint/no-unsafe-call,@typescript-eslint/no-unsafe-assignment
const specs = swaggerJsDoc(options);
const uiOptions: SwaggerUiOptions = { explorer: true };

// eslint-disable-next-line @typescript-eslint/no-unsafe-assignment
export const serve = swaggerUi.serve;
// eslint-disable-next-line @typescript-eslint/no-unsafe-assignment
export const setup = swaggerUi.setup(specs, uiOptions);

