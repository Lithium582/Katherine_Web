import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { LibroScreen } from './components/Libros/LibroScreen';
import { LibroABM } from './components/Libros/LibroABM';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Login} />
                <Route path='/home' component={Home} />
                <Route path='/counter' component={Counter} />
                <Route path='/fetch-data' component={FetchData} />
                <Route path='/LibroScreen' component={LibroScreen} />
                <Route path='/LibroABM' component={LibroABM} />
            </Layout>
        );
    }
}
