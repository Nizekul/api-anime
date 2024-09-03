<h2>Vagrant Configuração</h2>

Para rodar o Vagrant basta utilizar o comando `vagrant up` e para testar, acesse a vm1 com o comando `vagrant ssh vm1` após isso pode utilizar os seguintes comandos:

1. `ssh-keygen`
2. Defina um local para pasta ou siga com Enter para local padrão
3. defina uma senha ou Enter para senha vazia
4. `ssh-copy-id vagrant@192.168.56.11` depois `yes`
5. senha: `vagrant`
6. `cd /vagrant_data/`
6. `ansible-playbook -i inventory configurar-node.yml` 
7. Agora acesse a vm1 com `vagrant ssh vm1` em outra aba do terminal
8. Utilize o comando `curl -k https://192.168.56.11:7142/v1/AnimesFamosos` para testar a API


--------------------------------------------------------------------------------------------------------------------------
1. Abra o Visual Studio: Inicie o Visual Studio em seu computador.

2. Abra o Projeto: Abra o projeto da API no Visual Studio. Você pode fazer isso clicando em "File" (Arquivo) > "Open" (Abrir) > "Project/Solution" (Projeto/Solução) e navegando até a pasta onde está o arquivo de solução (.sln) do seu projeto.

3. Inicie a Depuração ou Execute sem Depurar: Agora você pode iniciar a depuração clicando em "Debug" (Depurar) > "Start Debugging" (Iniciar Depuração) ou pressionando F5 para iniciar o servidor e executar a API em modo de depuração. Se você quiser apenas executar a aplicação sem depuração, pode clicar em "Debug" (Depurar) > "Start Without Debugging" (Iniciar sem Depurar) ou pressionar Ctrl + F5.

4. Acesse a API: Após iniciar a API, você pode acessá-la usando um navegador da web ou uma ferramenta de teste de API, como o Postman ou Swagger. Por padrão, a API estará disponível em um endereço local, como "https://localhost:7142/". Caso ocorra algum erro de servidor no Postman tente desabilitar o SSL do Postman para testar a requisição.

5. Ao executar será encaminhado para a tela de Swagger onde observará os endpoints disponiveis.

6. Teste a API: Agora que a API está em execução, você pode testar os endpoints definidos na API usando os métodos HTTP apropriados (por exemplo, GET, POST, PUT, DELETE) e ver como a API responde aos diferentes tipos de solicitação.

7. Pare a Depuração

Será utilizado o Github flow pelos seguintes motivos: 
Simplicidade: O GitHub Flow é simples e fácil de entender, o que é para um time de apenas um membro. Ele se concentra em uma única ramificação principal e ciclos curtos de desenvolvimento, o que simplifica o processo de desenvolvimento.
Fluxo Linear: No GitHub Flow, o fluxo de trabalho é linear e direto. Cada funcionalidade ou correção é desenvolvida em sua própria branch, revisada e mesclada na branch principal que será a main, o que torna o acompanhamento do progresso e a resolução de conflitos mais simples.
