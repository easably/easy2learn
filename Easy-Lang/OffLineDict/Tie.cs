using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Tie
    {
        static Tie()
        {

            Types.Add("~", "Hyponym"); // может (Instance of)
            Types.Add("~i", "Has instance"); // era HAS INSTANCE => Caliphate => Instance of  "era"

            Types.Add("!", "Antonym"); // Antonyms s ≠
            Types.Add("&", "Similar");
            Types.Add("^", "Also see");

            Types.Add(">", "Cause");
            Types.Add("<", "Participle of verb");
            Types.Add("-u", "Show domain terms for usage");


            Types.Add("$", "Verb group");
            Types.Add(";c", "Show domain topic");
            Types.Add("@i", "Instance of");
            Types.Add("#s", "Substance meronym");
            Types.Add("\\", "Pertains to noun or derived from adjective");
            Types.Add("=", "Attribute");
            Types.Add("-r", "Show domain terms for region");
            Types.Add("#m", "Member meronym");
            Types.Add("#p", "Part meronym");
            Types.Add("%m", "Member holonym");
            Types.Add("%p", "Part holonym");
            Types.Add("*", "Entailment");
            Types.Add("-c", "Show domain terms for topic");
            Types.Add("%s", "Substance holonym");
            Types.Add(";r", "Show domain region");
            Types.Add("@", "Hypernyms"); // another name for superordinate
            Types.Add(";u", "Show domain usage");
        }

        static public Hashtable Types = new Hashtable();

    }
    /***
    *
          !	clear_up, clear, light_up, brighten - 2329748  overcast 0 cloud === Antonyms
       &	 industrial - 2509027 blue-collar === Similar
       >	shine - 2323851 shine 0 beam === Cause
       ^	overcast, cloud - 2329979 overcloud 0 cloud_over === Also see

       <	unsaponified - 455711 saponify === Participle of verb


       -u	British, British_people, Brits - 9296180 checker 1 chequer === Show domain terms for usage
    
       ~	overcast, cloud - 2330999 haze === 
           composer - 09021996 contrapuntist
		
       ~i	castle - 08322300 Balmoral_Castle === 
           composer - 09937078 songwriter 0 songster 1 ballad_maker
		
       $	scintillate - 2324804 twinkle 0 winkle 0 scintillate ===  Verb group
       ;c	twinkle, winkle, scintillate - 8660531 celestial_body 0 heavenly_body === Show domain topic
       @i	9/11, September_11, Sept._11, Sep_11 - 1111795 terrorist_attack === Instance of
       #s	zinc_oxide, flowers_of_zinc, philosopher's_wool, philosophers'_wool - 14269068 zinc_white === Substance meronym
       \\	wrongfully - 1327265 wrongful === Pertains to noun or derived from adjective
       =	clock_time, time - 138746 postmeridian ===  Attribute
       -r	South_America - 8449463 Latin_America === Show domain terms for region
       #m	hornblende - 13841489 amphibole_group === Member meronym
       #p	9/11, September_11, Sept._11, Sep_11 - 14369993 September === Part meronym
       %m	amphibole_group - 13900313 hornblende === Member holonym
       %p	menstrual_cycle - 14449031 safe_period === Part holonym
       *	thunder, boom - 2329021 storm === Entailment
       -c	Middle_Ages, Dark_Ages - 9897262 serf 0 helot 0 villein === Show domain terms for topic
       %s	zircon, zirconium_silicate - 13837758  zirconium === Substance holonym
       ;r	scrimshank - 8290950 === Show domain region
       @	deflagrate - 2322741  burn 2 combust === Hypernyms
       ;u	bide, abide, stay - 6613017 === Show domain usage
    * 
     * 
     * 
     * 
     * 
     * Most synsets are connected to other synsets via a number of semantic relations. These relations vary based on the type of word, and include:

       * Nouns
             o hypernyms: Y is a hypernym of X if every X is a (kind of) Y (canine is a hypernym of dog)
             o hyponyms: Y is a hyponym of X if every Y is a (kind of) X (dog is a hyponym of canine)
             o coordinate terms: Y is a coordinate term of X if X and Y share a hypernym (wolf is a coordinate term of dog, and dog is a coordinate term of wolf)
             o holonym: Y is a holonym of X if X is a part of Y (building is a holonym of window)
             o meronym: Y is a meronym of X if Y is a part of X (window is a meronym of house)
       * Verbs
             o hypernym: the verb Y is a hypernym of the verb X if the activity X is a (kind of) Y (travel is an hypernym of movement)
             o troponym: the verb Y is a troponym of the verb X if the activity Y is doing X in some manner (to lisp is a troponym of to talk)
             o entailment: the verb Y is entailed by X if by doing X you must be doing Y (to sleep is entailed by to snore)
             o coordinate terms: those verbs sharing a common hypernym (to lisp and to yell)
       * Adjectives
             o related nouns
             o similar to
             o participle of verb
       * Adverbs
             o root adjectives

    */
}