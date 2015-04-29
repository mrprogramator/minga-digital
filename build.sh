#!/bin/bash

has_dnvm ()
{
  source ~/.dnx/dnvm/dnvm.sh > /dev/null 2>&1 && type dnvm > /dev/null 2>&1;
}

install_dnvm ()
{
  curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh;
}

build ()
{
  set -e;
  
  if ! has_dnvm; then
    echo "==> installing dnvm"
    install_dnvm;
  fi
  
  echo "==> configuring nuget sources"
  mkdir -p ~/.config/NuGet;
  cp -f NuGet.Config ~/.config/NuGet;
  
  echo "==> upgrading dnx";
  dnvm upgrade -u;
  
  echo "==> building MingaDigital.App"
  cd src/MingaDigital.App;
  # dnu puede fallar la primera vez (BUG). lo corremos dos veces
  dnu restore || dnu restore;
  dnu build;
}

build;