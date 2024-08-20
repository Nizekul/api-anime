# -*- mode: ruby -*-
# vi: set ft=ruby :

# All Vagrant configuration is done below. The "2" in Vagrant.configure
# configures the configuration version (we support older styles for
# backwards compatibility). Please don't change it unless you know what
# you're doing.
Vagrant.configure("2") do |config|
  # The most common configuration options are documented and commented below.
  # For a complete reference, please see the online documentation at
  # https://docs.vagrantup.com.

  # Every Vagrant development environment requires a box. You can search for
  # boxes at https://vagrantcloud.com/search.
  config.vm.box = "ubuntu/xenial64"

  config.vm.box_check_update = false

  # config network
  config.vm.define :vm1 do |vm1|
    vm1.vm.network :private_network, :ip => "192.168.56.10"
  end

  config.vm.define :vm2 do |vm2|
   vm2.vm.network :private_network, :ip => "192.168.56.11"
   
   vm2.vm.provision "shell", inline: <<-SHELL
     # Atualizar o sistema e instalar dependências básicas
     sudo apt-get update
     sudo apt-get install -y wget git apt-transport-https

     # Baixar e instalar os pacotes Microsoft
     wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
     sudo dpkg -i packages-microsoft-prod.deb

     # Atualizar o sistema após adicionar os repositórios Microsoft
     sudo apt-get update

     # Instalar o .NET SDK novamente
     sudo apt-get install -y dotnet-sdk-6.0

     # Clonar o repositório da API do GitHub
     git clone https://github.com/Nizekul/api-anime.git /home/vagrant/api-anime

     # Modificar o arquivo launchSettings.json para usar 192.168.56.11
     sed -i 's/localhost/192.168.56.11/g' /home/vagrant/api-anime/api-animes/Properties/launchSettings.json

     # Buildar a API
     cd /home/vagrant/api-anime
     dotnet build

     # Executar a API
     cd api-animes
     dotnet run

   SHELL
  end

  # View the documentation for the provider you are using for more
  # information on available options.

  # Enable provisioning with a shell script. Additional provisioners such as
  # Ansible, Chef, Docker, Puppet and Salt are also available. Please see the
  # documentation for more information about their specific syntax and use.
end