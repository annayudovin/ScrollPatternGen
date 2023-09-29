# ScrollPatternGen
From wikipedia, under Scroll (art):
"The scroll in art is an element of ornament and graphic design featuring spirals and rolling incomplete circle motifs, some of which resemble the edge-on view of a book or document in scroll form, though many types are plant-scrolls, which loosely represent plant forms such as vines, with leaves or flowers attached. Scrollwork is a term for some forms of decoration dominated by spiralling scrolls, today used in popular language for two-dimensional decorative flourishes and arabesques of all kinds, especially those with circular or spiralling shapes."

The scroll motif is ubiquitous in the decorative traditions all over the world. Unfortunately, it's a pain to draw by hand, and the more complex of a design you want, the harder it is to plan out where and how to place the next swirl to keep it from looking stunted or artificial. I felt like the process could be improved with a bit of computation, and decided to give it a try - hence this little app. Feel free to play around with it - I can't promise you will ALWAYS like the results (I do, however, promise it's safe and won't blow anything up), but it does generally produce a variety of scroll designs with a fairly nice, "natural" feel to them.

<img width="434" alt="screenshot" src="https://github.com/annayudovin/ScrollPatternGen/assets/104697144/c8d3662f-f37c-4c03-951c-efee420ffff1">

The interface is a bit cluttered and complicated at first glance. I recommend starting out by trying the "leaf size variation" and "variation options" in the lower left.

The "leaf size variation" refers to the relative sizes of spirals that "grow" side-by-side from a single "parent" spiral. The default option selected when the app first loads starts by growing the smallest spirals first, progressing to the largest. If you want to see what they look like when the leaves are all the same size, uncheck the "dissimilar" option and press the "preview" button.

The different option numbers 1 through 5 tend to produce a different look-and-feel. Under the hood, these select a different set of fractions I used to divide up a circle ("triangle numbers" and the Fibonacci sequence make an appearance) - I tried a bunch of different options and narrowed it down to a set that both produced reasonable output and seemed most distinct in use.

In general, the "preview" button is what makes the image change, to reflect the options you've selected. However, changing the colors of the pattern or background doesn't require a "preview" click, and will be reflected once you've made your selection. So, if you have one of the random options selected, and like the current look, you can still change the colors without losing it.

When you generate an image you like and want to keep it, there are two options for doing so. Pressing the "copy" button will place the current image (with the currently selected colors) on the clipboard - you can paste it into Paint or anywhere else, rather like taking a screenshot, just without all the other stuff on the screen. Pressing the "svg" button next to it will save a vector image file (with an .svg extension) into a directory named ScrollGenerator (created on the first save) in your Documents folder. All of these will be named scroll-current-date-and-time (down to seconds, so you don't overwrite the last one you liked with the one you've just saved). 

Even if you've never used a vector graphic before and don't feel comfortable with them, I suggest saving an .svg just in case: the files generated are TINY (there's actually only formatted text inside), and the images can be scaled up or down without becoming grainy. Inkscape is a free application for working with vector graphics - if you are new to this, give it a try.

Oh, yeah, there are tooltips on all of the "clickable" controls that try to explain what each of them does, but since a picture is worth a thousand words, trying it out might prove more useful.
