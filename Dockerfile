FROM heroku/cedar:14

RUN apt-get update \
  && apt-get install -y curl \
  && rm -rf /var/lib/apt/lists/*

RUN apt-key adv --keyserver pgp.mit.edu --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF

RUN echo "deb http://download.mono-project.com/repo/debian wheezy/snapshots/4.0.0 main" > /etc/apt/sources.list.d/mono-xamarin.list \
  && apt-get update \
  && apt-get install -y mono-devel ca-certificates-mono fsharp mono-vbnc nuget \
  && rm -rf /var/lib/apt/lists/*

ENV DNX_VERSION 1.0.0-beta4
ENV DNX_USER_HOME /opt/dnx

RUN apt-get -qq update && apt-get -qqy install unzip

RUN curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_USER_HOME=$DNX_USER_HOME DNX_BRANCH=v$DNX_VERSION sh
RUN bash -c "source $DNX_USER_HOME/dnvm/dnvm.sh \
  && dnvm install $DNX_VERSION -a default \
  && dnvm alias default | xargs -i ln -s $DNX_USER_HOME/runtimes/{} $DNX_USER_HOME/runtimes/default"

# Install libuv for Kestrel from source code (binary is not in wheezy and one in jessie is still too old)
RUN apt-get -qqy install \
  autoconf \
  automake \
  build-essential \
  libtool

RUN LIBUV_VERSION=1.4.2 \
  && curl -sSL https://github.com/libuv/libuv/archive/v${LIBUV_VERSION}.tar.gz | tar zxfv - -C /usr/local/src \
  && cd /usr/local/src/libuv-$LIBUV_VERSION \
  && sh autogen.sh && ./configure && make && make install \
  && rm -rf /usr/local/src/libuv-$LIBUV_VERSION \
  && ldconfig

ENV PATH $PATH:$DNX_USER_HOME/runtimes/default/bin

RUN apt-get update \
  && apt-get install -y nodejs npm

# bower bug
RUN ln -s /usr/bin/nodejs /usr/bin/node

RUN useradd -d /app -m app
USER app
WORKDIR /app

ENV HOME /app
ENV PORT 3000

#RUN mkdir -p /app/heroku
#RUN mkdir -p /app/.profile.d

# TODO do something smarter?
RUN mkdir -p /tmp/prefetch/MingaDigital.App
RUN mkdir -p /tmp/prefetch/MingaDigital.Security
ADD ./src/MingaDigital.App/project.json /tmp/prefetch/MingaDigital.App/project.json
ADD ./src/MingaDigital.App/package.json /tmp/prefetch/MingaDigital.App/package.json
ADD ./src/MingaDigital.App/bower.json /tmp/prefetch/MingaDigital.App/bower.json
ADD ./src/MingaDigital.Security/project.json /tmp/prefetch/MingaDigital.Security/project.json

RUN cd /tmp/prefetch && dnu restore --parallel

EXPOSE 3000

ONBUILD RUN mkdir -p /app/src
ONBUILD COPY . /app/src
ONBUILD USER root
ONBUILD RUN chown -R app /app/src
ONBUILD USER app
ONBUILD WORKDIR /app/src
ONBUILD RUN dnu restore