#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.2
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Twitter Analysis practice (from website) (The Tech Academy)
#               (https://pythonprogramming.net/twitter-api-streaming-tweets-python-tutorial/?completed=/mysql-live-database-example-streaming-data/)
# Tested OS:    This code was written and tested to work with Windows 10.


from tweepy import Stream
from tweepy import OAuthHandler
from tweepy.streaming import StreamListener
import MySQLdb
import time
import json



#        replace mysql.server with "localhost" if you are running via your own server!
#                        server       MySQL username	MySQL pass  Database name.
conn = MySQLdb.connect("mysql.server","beginneraccount","cookies","beginneraccount$tutorial")

c = conn.cursor()


#consumer key, consumer secret, access token, access secret.
ckey="asdfasdfasdfasdfasdfasdf"
csecret="asdfasdfasdfasdfasdf"
atoken="asdf-asdfasdfasdf"
asecret="asdfasdfasdf"

class listener(StreamListener):

    def on_data(self, data):
        all_data = json.loads(data)
        
        tweet = all_data["text"]
        
        username = all_data["user"]["screen_name"]
        
        c.execute("INSERT INTO taula (time, username, tweet) VALUES (%s,%s,%s)",
            (time.time(), username, tweet))

        conn.commit()

        print((username,tweet))
        
        return True

    def on_error(self, status):
        print(status)

auth = OAuthHandler(ckey, csecret)
auth.set_access_token(atoken, asecret)

twitterStream = Stream(auth, listener())
twitterStream.filter(track=["car"])
