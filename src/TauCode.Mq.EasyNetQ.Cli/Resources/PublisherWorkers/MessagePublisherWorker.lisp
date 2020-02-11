(defblock :name publish-message :is-top t
	(worker
		:worker-name publish-message
		:verb "msg"
		:description "Publishes a message."
		:usage-samples (
			"pub msg 'Foo.Messages.HelloMessage' '{'Greeting' : 'Hello!'}'"
			"pub msg ema -f c:/temp/my-sample.json"
			"pub msg Email -c"
			))

	(some-text
		:classes term string
		:action argument
		:alias type-name
		:description "Type name, or part of type name."
		:doc-subst "type name")

	(alt
		(some-text
			:classes string
			:action argument
			:alias json
			:description "JSON representation of the message."
			:doc-subst "message JSON")

		(seq
			(multi-text
				:classes key
				:values "-f" "--file"
				:alias file
				:action key)

			(some-text
				:classes path string
				:action value
				:description "Path to a file which content to use as message JSON."
				:doc-subst "path to JSON file")
		)

		(multi-text
			:classes key
			:values "-c" "--clipboard"
			:alias clipboard
			:action option
			:description "Use clipboard as a source of messge JSON."
			:doc-subst "path to JSON file")
	)

	(end)
)
