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
  config.vm.box = "generic/debian12"

  config.vm.box_check_update = false

  # config network
  config.vm.define :vm1 do |vm1|
    vm1.vm.network :private_network, :ip => "192.168.56.10"
    vm1.vm.synced_folder "./data", "/vagrant_data"
    vm1.vm.provision "shell", inline: <<-SHELL
      apt-get update
      apt install software-properties-common
      add-apt-repository --yes --update ppa:ansible/ansible
      apt install -y ansible
    SHELL
  end

  config.vm.define :vm2 do |vm2|
   vm2.vm.network :private_network, :ip => "192.168.56.11"
  end

  # View the documentation for the provider you are using for more
  # information on available options.

  # Enable provisioning with a shell script. Additional provisioners such as
  # Ansible, Chef, Docker, Puppet and Salt are also available. Please see the
  # documentation for more information about their specific syntax and use.
end