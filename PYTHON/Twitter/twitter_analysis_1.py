#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.5
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Twitter Analysis practice (from video) (The Tech Academy)
#               (https://www.youtube.com/watch?v=7tYjUOAh8KU)
# Tested OS:    This code was written and tested to work with Windows 10.


from tweepy import Stream
from tweepy import OAuthHandler
from tweepy.streaming import StreamListener
import urllib

#consumer key, consumer secret, access token, access secret.
ckey="asdfasdfasdfasdfasdfasdf"
csecret="asdfasdfasdfasdfasdf"
atoken="asdf-asdfasdfasdf"
asecret="asdfasdfasdf"

######
sentdexAuth = ''


def sentimentAnalysis(text):
    encoded_text = urllib.quote(text)
    API_Call = 'http://sentdex.com/api/api.php?text='+encoded_text+'&auth='+sentdexAuth
    output = urllib.urlopen(API_Call).read()

    return output

class listener(StreamListener):

    def on_data(self, data):
        tweet = data.split('","text":"')[1].split('","source')[0]
        sentimentRating = sentimentAnalysis(tweet)

        saveMe = tweet+'::'+sentimentRating+'\n'
        output = open('output.csv','a')
        output.write(saveMe)
        output.close()
        return(True)

    def on_error(self, status):
        print(status)

auth = OAuthHandler(ckey, csecret)
auth.set_access_token(atoken, asecret)

twitterStream = Stream(auth, listener())
twitterStream.filter(track=["car"])
